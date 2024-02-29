import { Box } from "@mui/material";
import useStyles from "./styles";
const Autenticacao = () => {
  const styles = useStyles();

  return (
    <main>
      <Box sx={styles.background} />
      <Box sx={styles.tela}>
        <Box sx={styles.container}>
          <Box sx={styles.coqueiroBox}>
            <img style={styles.coqueiro} src="images/coqueiro.svg" />
          </Box>
          <Box sx={styles.login}>
            <Box sx={styles.logo} />
          </Box>
        </Box>
      </Box>
    </main>
  );
};

export default Autenticacao;
